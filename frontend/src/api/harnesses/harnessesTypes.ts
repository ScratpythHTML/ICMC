import type { Sex, Size, StorageLocation } from '../common/enums';

export interface AddHarnessRequest {
  toughTag: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
  size?: Size;
  sex?: Sex;
}

export interface UpdateHarnessRequest {
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
  sex?: Sex;
}

export interface HarnessDto {
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
  sex?: Sex;
  storageLocation: StorageLocation;
  lentTo?: number;
  lentBy?: number;
  returnedDate?: string;
}
