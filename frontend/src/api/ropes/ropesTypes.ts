import { StorageLocation } from '../common/enums';

export interface AddRopeRequest {
  toughTag: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  length?: number;
}

export interface UpdateRopeRequest {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  length?: number;
}

export interface RopeDto {
  id: number;
  toughTag?: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  length?: number;
  storageLocation: StorageLocation;
  lentTo?: number;
  lentBy?: number;
  returnedDate?: string;
}
