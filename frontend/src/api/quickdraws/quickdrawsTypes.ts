import { StorageLocation } from '../common/enums';

export interface AddQuickdrawRequest {
  toughTag: number;
  brand?: string;
  model?: number;
  dateOfPurchase?: string;
  manufacturerExpiry?: string;
  lastInspection?: string;
  nextInspection?: string;
  inspectedBy?: number;
}

export interface UpdateQuickdrawRequest {
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

export interface QuickdrawDto {
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
