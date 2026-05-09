import { StorageLocation } from '../common/enums';

export interface AddBelayDeviceRequest {
  ToughTag: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
}

export interface UpdateBelayDeviceRequest {
  Id: number;
  ToughTag?: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
}

export interface BelayDeviceDto {
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
