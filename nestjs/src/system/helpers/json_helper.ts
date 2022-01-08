function getCircularReplacer() {
  const seen = new WeakSet();
  return (key: string, value: any) => {
    if (typeof value === "object" && value !== null) {
      if (seen.has(value)) {
        return;
      }
      seen.add(value);
    }
    return value;
  };
}

export function json_encode(content: any) {
  return JSON.stringify(content, getCircularReplacer());
}

export function json_decode(content: any) {
  return JSON.parse(content);
}

export function json_object(content: any) {
  return json_decode(json_encode(content));
}
