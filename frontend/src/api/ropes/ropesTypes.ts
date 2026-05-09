import { StorageLocation } from '../common/enums';

export interface AddRopeRequest {
  ToughTag: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Length?: number;
}

export interface UpdateRopeRequest {
  Id: number;
  ToughTag?: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Length?: number;
}

export interface RopeDto {
  Id: number;
  ToughTag?: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Length?: number;
  StorageLocation: StorageLocation;
  LentTo?: number;
  LentBy?: number;
  ReturnedDate?: string;
}
