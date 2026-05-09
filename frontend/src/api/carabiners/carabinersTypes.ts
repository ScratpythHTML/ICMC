import { StorageLocation } from '../common/enums';

export interface AddCarabinerRequest {
  toughTag: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
}

export interface UpdateCarabinerRequest {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
}

export interface CarabinerDto {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  storageLocation: StorageLocation;
  lentTo?: number;
  lentBy?: number;
  returnedDate?: string;
}
