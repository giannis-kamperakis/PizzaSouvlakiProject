/* tslint:disable */
/* eslint-disable */
import { FoodType } from './food-type';
export interface Pizza {
  
  id?: null | string;
  name?: null | string;
  price?: null | string;
  smallDescription?: null | string;
  bigDescription?: null | string;
  type?: FoodType;
  showBigDescription?: boolean;
}
