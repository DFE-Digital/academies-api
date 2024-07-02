module.exports = [
  {
    files: [
      ".js",".jsx",".ts",".tsx"
    ],
    rules: {
      "cypress/no-assigning-return-values": "error",
      "cypress/no-unnecessary-waiting": "error",
      "cypress/assertion-before-screenshot": "error",
      "cypress/no-force": "error",
      "cypress/no-async-tests": "error",
      "cypress/no-pause": "error"
    },
    plugins: [
      "cypress"
    ],
    env: {
      "cypress/globals": true
    },
    extends: [
      "plugin:cypress/recommended"
    ]
  }
]