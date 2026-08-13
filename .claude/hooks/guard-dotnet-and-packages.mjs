const DOTNET_RE = /(^|[\s;&|])dotnet(\s|$)/i;

const PACKAGE_COMMAND_RES = [
  /\bnuget\s+(install|update|push)\b/i,
  /\bmsbuild\b.*\b(\/t:restore|-t:restore)\b/i,
  /\bnpm\s+(install|i|update|up|ci|add)\b/i,
  /\byarn\s+(add|upgrade|install)\b/i,
  /\bpnpm\s+(add|update|up|install)\b/i,
  /\bpip\s+install\b/i,
  /\bchoco(latey)?\s+install\b/i,
  /\bwinget\s+install\b/i,
  /Install-Package\b/i,
  /Install-Module\b/i,
];

function isBlockedCommand(command) {
  if (DOTNET_RE.test(command)) return "dotnet 명령";
  for (const re of PACKAGE_COMMAND_RES) {
    if (re.test(command)) return "패키지 설치/업데이트 명령";
  }
  return null;
}

let data = "";
process.stdin.on("data", (chunk) => {
  data += chunk;
});
process.stdin.on("end", () => {
  try {
    const payload = JSON.parse(data);
    const command = payload.tool_input?.command ?? "";
    const toolName = payload.tool_name ?? "";

    if (toolName === "Bash" || toolName === "PowerShell") {
      const reason = isBlockedCommand(command);
      if (reason) {
        console.log(
          JSON.stringify({
            hookSpecificOutput: {
              hookEventName: "PreToolUse",
              permissionDecision: "deny",
              permissionDecisionReason:
                `이 환경(작성 PC)에서는 ${reason}을 실행할 수 없다 (CLAUDE.md 환경 규칙, spec.md §7). ` +
                `.NET SDK가 없고 패키지 설치/업데이트는 절대 금지다. 필요하면 엔지니어에게 검증 PC에서 수동으로 실행해 달라고 요청하라.`,
            },
          })
        );
      }
    }
  } catch {
    // fail open: never block on a parsing error
  }
  process.exit(0);
});
