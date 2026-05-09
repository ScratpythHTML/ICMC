import type { Sex, Size, StorageLocation } from '../common/enums';

export interface AddHarnessRequest {
  ToughTag: number;
  Brand?: string;
  Model?: number;
  DateOfPurchase?: string;
  ManufacturerExpiry?: string;
  LastInspection?: string;
  NextInspection?: string;
  InspectedBy?: number;
  Size?: Size;
  Sex?: Sex;
}

export interface UpdateHarnessRequest {
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
  Sex?: Sex;
}

export interface HarnessDto {
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
  Sex?: Sex;
  StorageLocation: StorageLocation;
  LentTo?: number;
  LentBy?: number;
  ReturnedDate?: string;
}
