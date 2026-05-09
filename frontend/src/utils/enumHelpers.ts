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
