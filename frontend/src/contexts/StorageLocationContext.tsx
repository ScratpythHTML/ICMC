import { createContext, useContext, useState } from 'react';

type StorageLocation = 'imperial' | 'westway';
type StorageLocationContextType = {
  storageLocation: StorageLocation;
  setStorageLocation: (storageLocation: StorageLocation) => void;
};

const StorageLocationContext = createContext<StorageLocationContextType | null>(
  null
);

export const StorageLocationProvider = ({
  children,
}: {
  children: React.ReactNode;
}) => {
  const [storageLocation, setStorageLocation] =
    useState<StorageLocation>('imperial');

  return (
    <StorageLocationContext.Provider
      value={{ storageLocation, setStorageLocation }}
    >
      {children}
    </StorageLocationContext.Provider>
  );
};

export const useStorageLocation = () => {
  const context = useContext(StorageLocationContext);
  if (!context) {
    throw new Error(
      'useStorageLocation must be used within StorageLocationProvider'
    );
  }
  return context;
};
