export function repeatedQueryParams(
  key: string,
  values: readonly (string | number)[],
): URLSearchParams {
  const params = new URLSearchParams();

  for (const value of values) {
    params.append(key, String(value));
  }

  return params;
}
