import type { GearCategory, Sex, Size, StorageLocation } from '../common/enums';

export interface AddGearItemRequest {
  brand?: string;
  dateOfPurchase?: string;
  expectedReturnDate?: string;
  gearCategory: GearCategory;
  imageUrl?: string;
  inspectedByUserId?: number;
  lastInspection?: string;
  lentByUserId?: number;
  lentDate?: string;
  lentToUserId?: number;
  length?: number;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation: StorageLocation;
  toughTag?: string;
}

export interface UpdateGearItemRequest {
  id: number;
  brand?: string;
  dateOfPurchase?: string;
  expectedReturnDate?: string;
  gearCategory?: GearCategory;
  imageUrl?: string;
  inspectedByUserId?: number;
  lastInspection?: string;
  lentByUserId?: number;
  lentDate?: string;
  lentToUserId?: number;
  length?: number;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation?: StorageLocation;
  toughTag?: string;
}

export interface GearItemDto {
  id: number;
  brand?: string;
  dateOfPurchase?: string;
  expectedReturnDate?: string;
  gearCategory?: GearCategory;
  imageUrl?: string;
  inspectedByUserId?: number;
  lastInspection?: string;
  length?: number;
  lentByUserId?: number;
  lentDate?: string;
  lentToUserId?: number;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation?: StorageLocation;
  toughTag?: string;
}

export interface SearchGearItemsRequest {
  brand?: string;
  dateOfPurchase?: string;
  expectedReturnDate?: string;
  gearCategory?: GearCategory;
  inspectedByUserId?: number;
  lastInspection?: string;
  length?: number;
  lentByUserId?: number;
  lentDate?: string;
  lentToUserId?: number;
  manufacturerExpiry?: string;
  model?: string;
  nextInspection?: string;
  returnedDate?: string;
  sex?: Sex;
  size?: Size;
  storageLocation?: StorageLocation;
  toughTag?: string;
}
