export interface AddBelayDeviceRequest {
  ToughTag: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: string;
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
  InspectedBy?: string;
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
  inspectedBy?: string;
}

export type StorageLocation = 'imperial' | 'westway';
