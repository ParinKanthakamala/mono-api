export class Email {
  private from: string;
  private to: [];

  constructor(from: string, to: []) {
    this.from = from;
    this.to = to;
  }
}
