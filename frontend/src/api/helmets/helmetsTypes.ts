import type { Size, StorageLocation } from '../common/enums';

export interface AddHelmetRequest {
  ToughTag: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Size?: Size;
}

export interface UpdateHelmetRequest {
  Id: number;
  ToughTag?: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Size?: Size;
}

export interface HelmetDto {
  Id: number;
  ToughTag?: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Size?: Size;
  StorageLocation: StorageLocation;
  LentTo?: number;
  LentBy?: number;
  ReturnedDate?: string;
}
