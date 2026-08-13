# CLAUDE.md

이 프로젝트는 "AI 코드 생성 리뷰 자동화" 자체를 설계·구축하는 프로젝트다. 전체 배경은 `BRIEF.md`, 확정 스펙은 `spec.md`, 실행 백로그는 `backlog.json`을 참조한다.

이 문서는 **main agent**(이 세션)가 대상 프로젝트에서 개발을 진행할 때 항상 지키는 운영 규칙이다. sub agent/skill의 역할 정의는 `spec.md` §3.2, 실제 구현은 `.claude/skills/analyze-project-rules/`, `.claude/agents/task-recorder.md`, `.claude/agents/review-checker.md`를 참조한다.

## 환경 규칙 (항상 적용, 예외 없음)

- 이 환경은 **작성 PC**다. .NET SDK가 없고, `dotnet` 명령을 실행하지 않는다. (`.claude/hooks/guard-dotnet-and-packages.mjs`가 Bash/PowerShell에서 이를 강제 차단한다.)
- **패키지 설치·업데이트·다운로드를 절대 하지 않는다.** 필요하면 코드를 작성하지 말고 엔지니어에게 수동 작업을 요청한다.
- 컴파일러 검증이 필요한 판단(타입 추론, 오버로드 해석, nullable 경고 등)은 추측하지 않고 **"미검증"**으로 표시해 검증 PC로 넘긴다.
- 회피 대상: 확인되지 않은 API·오버로드 사용, 대상 프레임워크가 지원하는지 불확실한 언어 기능.
- 실제 빌드·테스트(검증)는 검증 PC에서 진행한다. 여기서 리뷰가 문제 없이 통과하면, 이후 미진 사항 보완·재설계·개발은 검증 PC에서 자체적으로 이어간다. 오류를 이 세션으로 다시 가져와 리뷰를 반복하는 절차는 두지 않는다.

## Task 루프

```
Task N: 사전검토 → 개발 → 리뷰 → 기록 → Task N+1: 사전검토 → ...
```

토큰 제약상 Task 단위로 루프를 완결한다. 한 Task의 기록까지 끝내고 나서 다음 Task의 사전검토로 넘어간다.

### 1. 사전검토
- `documents/requirements/<Task ID>.md`(요구사항 문서)가 없으면 새로 작성하고, 있으면 최신 상태인지 확인한다. 작성 후 엔지니어 승인을 받는다.
- 수정/개발이 필요한 영역과 사유를 정리해 엔지니어에게 공유하고 합의받는다.
- 예상 변경 파일 수 상한을 이 단계에서 합의한다. **전역 기본값 없음 — 매 Task마다 새로 확인한다.** 상한을 넘어서면 Task를 쪼갤지 엔지니어에게 확인한다.
- `RULES.md`(내부 룰 파일)가 없거나 오래되었으면 개발 전에 `analyze-project-rules` skill을 먼저 실행할지 확인한다.

### 2. 개발
- `documents/requirements/<Task ID>.md`의 범위와 완료 기준을 벗어나지 않는다. 범위를 벗어나야 할 이유가 생기면 코드를 쓰기 전에 요구사항 문서를 먼저 갱신하고 엔지니어 확인을 받는다.
- `RULES.md`에 정의된 컨벤션을 벗어나지 않는 범위에서 구현한다.
- 사전검토에서 합의한 핵심 클래스 외 영역을 수정해야 하는 상황이 생기면 **즉시 중단**하고 엔지니어 확인을 먼저 받는다.
- 패키지 설치/업데이트, `dotnet` 실행 금지 (환경 규칙 참조).

### 3. 리뷰
- **Critical/Major/Minor 등급 기준은 전역 기본값이 없다 — 이 Task를 리뷰하기 전에 엔지니어에게 먼저 확인한다.**
- `review-checker` subagent를 호출해 요구사항 반영 여부, (엔지니어와 합의한 기준의) Critical/Major/Minor 이슈, [검증 PC 확인 필요] 목록을 받는다.
- 호출 시 Task ID, `documents/requirements/<Task ID>.md` 경로, 변경 파일 목록(또는 diff), `RULES.md` 경로, 합의된 이슈 등급 기준을 전달한다.

### 4. 기록
- `task-recorder` subagent를 호출해 사전검토 요약/리뷰 결과/완료 판정을 기록 파일에 추가한다.
- 기록 파일의 "요구사항 요약"은 `documents/requirements/<Task ID>.md`의 한 줄 요약을 인용한다.
- 작성 완료·검증 완료는 분리해서 기록한다 (아래 판정 기준 참조).
- 리뷰 이슈 중 **3회 이상 반복된 패턴**은 이 문서의 [팀 컨벤션] 섹션에 규칙으로 추가한다.

## Task 완료 판정 (2단계)

| 상태 | 판정 기준 |
|---|---|
| [작성 완료] | 리뷰 Critical 0건 + 엔지니어 승인 |
| [검증 완료] | 검증 PC 빌드 성공 + 테스트 통과 |

두 상태는 기록 파일에 항상 분리해서 남긴다. 하나가 없다고 다른 하나를 추측해서 채우지 않는다.

## 요구사항 문서

- 위치: 대상 프로젝트 루트 기준 `documents/requirements/<Task ID>.md`. 자동화 시스템 문서(`spec.md`, `backlog.json`)와는 별개로, **개발 대상 프로젝트**에 귀속된다.
- 각 Task의 사전검토 단계에서 main agent가 작성/갱신하고 엔지니어 승인을 받는다. 필수 항목: Task ID/한 줄 요약, 요구사항 상세, 완료 기준(Acceptance Criteria), 영향 범위, 참조(외부 티켓이 있으면 링크).
- 리뷰(`review-checker`)와 기록(`task-recorder`) 모두 이 문서를 근거로 삼는다. 요구사항 자체가 불명확하면 개발에 들어가지 않는다.

## 내부 룰 파일

- 위치(확정): 프로젝트 루트 `RULES.md` (프로젝트별 1회성 생성, `.claude/skills/analyze-project-rules/`가 담당).
- main agent는 개발 시 이 파일을 벗어나지 않는다. 벗어나야 할 이유가 있으면 코드를 쓰기 전에 엔지니어에게 먼저 알린다.

## 기록 파일

- 위치(확정): `documents/execute_report/<Task ID>.md`
- 형식은 `task-recorder` subagent 정의를 따른다.

## 팀 컨벤션 (반복 이슈 3회 이상 → 여기에 규칙 추가)

_아직 없음. 리뷰에서 동일/유사 이슈가 3회 이상 나오면 main agent가 이 섹션에 규칙을 추가한다._

## 매 Task마다 개별 확인해야 하는 항목 (전역 기본값 없음, spec.md §12)

- **Task당 변경 파일 수 상한**: 사전검토 단계에서 매번 새로 확인 (위 "1. 사전검토" 참조)
- **리뷰 이슈 등급(Critical/Major/Minor) 기준**: 리뷰 단계에서 매번 새로 확인 (위 "3. 리뷰" 참조)

## 확정 사항 (spec.md §12)

- sub agent(룰 분석)와 main agent(개발) 간 호출 인터페이스: 룰 분석은 skill(`analyze-project-rules`), 기록·리뷰는 subagent(`task-recorder`, `review-checker`)로 확정 (2026-08-13).

미확정 사항 없음.
