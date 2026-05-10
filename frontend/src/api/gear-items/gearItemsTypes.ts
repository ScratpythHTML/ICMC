import type { GearCategory, Sex, Size, StorageLocation } from '../common/enums';

export interface AddGearItemRequest {
  toughTag: number;
  brand?: string;
  model?: string;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: string;
  lentTo?: string;
  lentBy?: string;
  lentDate?: string;
  returnedDate?: string;
  storageLocation: StorageLocation;
  size?: Size;
  sex?: Sex;
  length?: number;
  gearCategory: GearCategory;
}

export interface UpdateGearItemRequest {
  id: number;
  brand?: string;
  dateOfPurchase?: string;
  gearCategory?: GearCategory;
  inspectedBy?: string;
  lastInspection?: string;
  length?: number;
  lentBy?: string;
  lentDate?: string;
  lentTo?: string;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation?: StorageLocation;
  toughTag?: number;
}

export interface GearItemDto {
  id: number;
  brand?: string;
  dateOfPurchase?: string;
  gearCategory: GearCategory;
  inspectedBy?: string;
  lastInspection?: string;
  length?: number;
  lentBy?: string;
  lentDate?: string;
  lentTo?: string;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation: StorageLocation;
  toughTag?: number;
}

export interface GetGearItemsRequest {
  storageLocation?: StorageLocation;
  gearCategory?: GearCategory;
}
