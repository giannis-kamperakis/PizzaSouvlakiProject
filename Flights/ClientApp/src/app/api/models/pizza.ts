/* tslint:disable */
/* eslint-disable */
import { PizzaType } from './pizza-type';
export interface Pizza {
  bigDescription?: null | string;
  id?: string;
  name?: null | string;
  price?: number;
  smallDescription?: null | string;
  type?: PizzaType;
}
