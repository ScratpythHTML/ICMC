import { colours } from '@styles/variables';
import { GearCategory, Sex, Size, StorageLocation } from '../api/common/enums';

export const getGearCategoryLabel = (category?: GearCategory): string => {
  if (category === undefined) return 'Unknown';
  switch (category) {
    case GearCategory.BelayDevice:
      return 'Belay Device';
    case GearCategory.Carabiner:
      return 'Carabiner';
    case GearCategory.Crashpad:
      return 'Crashpad';
    case GearCategory.Harness:
      return 'Harness';
    case GearCategory.Helmet:
      return 'Helmet';
    case GearCategory.Quickdraw:
      return 'Quickdraw';
    case GearCategory.Rope:
      return 'Rope';
    default:
      return 'Other';
  }
};

export const getSexLabel = (sex?: Sex): string => {
  if (sex === undefined) return 'Unisex';
  switch (sex) {
    case Sex.Male:
      return 'Male';
    case Sex.Female:
      return 'Female';
    default:
      return 'Unisex';
  }
};

export const getSizeLabel = (size?: Size): string => {
  if (size === undefined) return 'N/A';
  switch (size) {
    case Size.XXS:
      return 'XXS';
    case Size.XS:
      return 'XS';
    case Size.S:
      return 'S';
    case Size.M:
      return 'M';
    case Size.L:
      return 'L';
    case Size.XL:
      return 'XL';
    case Size.XXL:
      return 'XXL';
    default:
      return 'N/A';
  }
};

export const getStorageLocationLabel = (location?: StorageLocation): string => {
  if (location === undefined) return 'Unknown';
  switch (location) {
    case StorageLocation.Imperial:
      return 'Imperial';
    case StorageLocation.Westway:
      return 'Westway';
    default:
      return 'Unknown';
  }
};

export const formatDate = (dateString?: string): string => {
  if (!dateString) return 'N/A';
  try {
    const date = new Date(dateString);
    return date.toLocaleDateString();
  } catch {
    return 'Invalid Date';
  }
};

export const getInspectionStatus = (nextInspection?: string) => {
  if (!nextInspection) return { label: 'No Inspection', color: colours.grey };

  const today = new Date();
  const inspectionDate = new Date(nextInspection);
  const diffTime = inspectionDate.getTime() - today.getTime();
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

  if (diffDays < 0) {
    return { label: 'Overdue', color: colours.purpleLight }; // Red-ish
  }
  if (diffDays <= 30) {
    return { label: 'Due Soon', color: colours.orangeLight }; // Orange
  }
  return { label: 'OK', color: colours.green }; // Green
};

export const getLendingStatus = (lentTo?: number) => {
  if (lentTo && lentTo > 0) {
    return { label: 'Lent Out', color: colours.purpleLight }; // Red-ish
  }
  return { label: 'Available', color: colours.green }; // Green
};

export const getSizeOptions = () => [
  { label: 'XXS', value: Size.XXS },
  { label: 'XS', value: Size.XS },
  { label: 'S', value: Size.S },
  { label: 'M', value: Size.M },
  { label: 'L', value: Size.L },
  { label: 'XL', value: Size.XL },
  { label: 'XXL', value: Size.XXL },
];

export const getSexOptions = () => [
  { label: 'Male', value: Sex.Male },
  { label: 'Female', value: Sex.Female },
];

export const getStorageLocationOptions = () => [
  { label: 'Imperial', value: StorageLocation.Imperial },
  { label: 'Westway', value: StorageLocation.Westway },
];

export const getGearCategoryOptions = () => [
  { label: 'Belay Device', value: GearCategory.BelayDevice },
  { label: 'Carabiner', value: GearCategory.Carabiner },
  { label: 'Crashpad', value: GearCategory.Crashpad },
  { label: 'Harness', value: GearCategory.Harness },
  { label: 'Helmet', value: GearCategory.Helmet },
  { label: 'Quickdraw', value: GearCategory.Quickdraw },
  { label: 'Rope', value: GearCategory.Rope },
];
