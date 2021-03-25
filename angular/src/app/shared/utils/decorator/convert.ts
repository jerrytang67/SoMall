import { NzSafeAny } from 'ng-zorro-antd/core/types';

declare const ngDevMode: boolean;

const record: Record<string, boolean> = {};

export const PREFIX = '[@DELON]:';

function notRecorded(...args: NzSafeAny[]): boolean {
  const asRecord = args.reduce((acc, c) => acc + c.toString(), '');

  if (record[asRecord]) {
    return false;
  } else {
    record[asRecord] = true;
    return true;
  }
}

function consoleCommonBehavior(consoleFunc: (...args: NzSafeAny) => void, ...args: NzSafeAny[]): void {
  if (ngDevMode && notRecorded(...args)) {
    consoleFunc(...args);
  }
}

// Warning should only be printed in dev mode and only once.
export const warn = (...args: NzSafeAny[]) => consoleCommonBehavior((...arg: NzSafeAny[]) => console.warn(PREFIX, ...arg), ...args);

export const deprecation11 = (comp: string, from: string, to?: string) => {
  warnDeprecation(`${comp} => '${from}' is going to be removed in 11.0.0${to ? `, Please use '${to}' instead` : ``}.`);
};

export const warnDeprecation = (...args: NzSafeAny[]) => {
  if (ngDevMode) {
    return () => {};
  }
  const stack = new Error().stack;
  return consoleCommonBehavior((...arg: NzSafeAny[]) => console.warn(PREFIX, 'deprecated:', ...arg, stack), ...args);
};

// Log should only be printed in dev mode.
export const log = (...args: NzSafeAny[]) => {
  if (ngDevMode) {
    console.log(PREFIX, ...args);
  }
};

function propDecoratorFactory<T, D>(
  name: string,
  fallback: (v: T, defaultValue: D) => D,
  defaultValue: NzSafeAny,
): (target: NzSafeAny, propName: string) => void {
  function propDecorator(target: NzSafeAny, propName: string, originalDescriptor?: TypedPropertyDescriptor<NzSafeAny>): NzSafeAny {
    const privatePropName = `$$__${propName}`;

    if (Object.prototype.hasOwnProperty.call(target, privatePropName)) {
      warn(`The prop "${privatePropName}" is already exist, it will be overrided by ${name} decorator.`);
    }

    Object.defineProperty(target, privatePropName, {
      configurable: true,
      writable: true,
    });

    return {
      get(): string {
        return originalDescriptor && originalDescriptor.get ? originalDescriptor.get.bind(this)() : this[privatePropName];
      },
      set(value: T): void {
        if (originalDescriptor && originalDescriptor.set) {
          originalDescriptor.set.bind(this)(fallback(value, defaultValue));
        }
        this[privatePropName] = fallback(value, defaultValue);
      },
    };
  }

  return propDecorator;
}

export function toBoolean(value: any, allowUndefined: boolean | null = false): boolean | undefined {
  return allowUndefined && typeof value === 'undefined' ? undefined : value != null && `${value}` !== 'false';
}

/**
 * Input decorator that handle a prop to do get/set automatically with toBoolean
 *
 * ```ts
 * {AT}Input() {AT}InputBoolean() visible: boolean = false;
 * {AT}Input() {AT}InputBoolean(null) visible: boolean = false;
 * ```
 */
export function InputBoolean(defaultValue: boolean | null = false): any {
  return propDecoratorFactory('InputNumber', toBoolean, defaultValue);
}

export function toNumber(value: any): number;
export function toNumber<D>(value: any, fallback: D): number | D;
export function toNumber(value: any, fallbackValue: number = 0): number {
  return !isNaN(parseFloat(value as any)) && !isNaN(Number(value)) ? Number(value) : fallbackValue;
}

/**
 * Input decorator that handle a prop to do get/set automatically with toNumber
 *
 * ```ts
 * {AT}Input() {AT}InputNumber() visible: number = 1;
 * {AT}Input() {AT}InputNumber(null) visible: number = 2;
 * ```
 */
export function InputNumber(defaultValue: number | null = 0): any {
  return propDecoratorFactory('InputNumber', toNumber, defaultValue);
}


/**
 * Used to verify `<ng-content></ng-content>` is empty, useful for custom components.
 *
 * 用于校验 `<ng-content></ng-content>` 是否为空，自定义组件时蛮有用。
 */
 export function isEmpty(element: HTMLElement): boolean {
  const nodes = element.childNodes;
  for (let i = 0; i < nodes.length; i++) {
    const node = nodes.item(i);
    if (node.nodeType === 1 && (node as HTMLElement).outerHTML.toString().trim().length !== 0) {
      return false;
    } else if (node.nodeType === 3 && node.textContent!.toString().trim().length !== 0) {
      return false;
    }
  }
  return true;
}
