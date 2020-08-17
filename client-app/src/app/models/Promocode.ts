export interface IPromocode {
  id: string;
  code: string;
  dateCreate: string;
  status: string;
  dateStartUsing: string;
  dateFinishUsing: string;
}

export class PromocodeClass implements IPromocode {
  id: string = "";
  code: string = "";
  dateCreate: string = "";
  status: string = "";
  dateStartUsing: string = "";
  dateFinishUsing: string = "";
  constructor(init?: PromocodeClass) {
    Object.assign(this, init);
  }
}
