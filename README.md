# ModJar-Builder

## Forge & Java Compatibility Chart

This tool works with any Forge version, as long as the correct Java version is used.

### Forge → Java Version Requirements

| Minecraft Version     | Forge Version Range | Required Java Version |
|-----------------------|---------------------|-----------------------|
| **1.20.5 – 1.21+**    | 50+                 | **Java 21**           |
| **1.20 – 1.20.4**     | 46–49               | **Java 17**           |
| **1.19 – 1.19.4**     | 41–45               | **Java 17**           |
| **1.18 – 1.18.2**     | 38–40               | **Java 17**           |
| **1.17.x**            | (skipped)           | N/A                   |
| **1.16 – 1.16.5**     | 32–36               | **Java 8**            |
| **1.15 – 1.15.2**     | 29–31               | **Java 8**            |
| **1.14 – 1.14.4**     | 26–28               | **Java 8**            |
| **1.13.x**            | 24–25               | **Java 8**            |
| **1.12.2**            | 14                  | **Java 8**            |
| **1.11.x**            | 13                  | **Java 8**            |
| **1.10.x**            | 12                  | **Java 8**            |
| **1.9.x**             | 11                  | **Java 8**            |
| **1.8.x**             | 8                   | **Java 8**            |
| **1.7.10**            | 7                   | **Java 7 or 8**       |

### Notes
- Forge 1.18+ requires Java 17 because Minecraft switched to Java 17.
- Forge 1.20.5+ requires Java 21 due to another JVM upgrade.
- Older Forge versions (1.12.2 and below) always use Java 8.
- If the wrong Java version is installed, Gradle will fail during the build.

### Additional Info

The ModJar-Builder-V1.0.0.zip is a fully functional version of ModJar BUilder that includes Java Runtime Environent 17 (jre17).

When using ModJar-Builder, it uses a lot of cpu usage (tested on Ryzen 5 3600).
