// info : collapse from index array to map
export function array_collapse(arr: string[]): any {
  const map: any = {};
  for (let i = 0; i < arr.length; i++) {
    const key = arr[i];
    const value = arr[++i];
    map[key] = value;
  }
  return map;
}

export function array_last(array: any) {
  return array[array.length - 1];
}
