import type { Size, StorageLocation } from '../common/enums';

export interface AddHelmetRequest {
  toughTag: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  size?: Size;
}

export interface UpdateHelmetRequest {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  size?: Size;
}

export interface HelmetDto {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  size?: Size;
  storageLocation: StorageLocation;
  lentTo?: number;
  lentBy?: number;
  returnedDate?: string;
}
