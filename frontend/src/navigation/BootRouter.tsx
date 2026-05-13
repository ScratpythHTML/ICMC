import type { GearCategory, StorageLocation } from '@api/common/enums';
import Account from '@pages/Account';
import Login from '@pages/Login';
import GearItem from '@pages/GearItem';
import TabRouter from './TabRouter';

import { createNativeStackNavigator } from '@react-navigation/native-stack';

export type RootStackParamList = {
  Login: undefined;
  Main: undefined;
  Account: undefined;
  GearItem: { id: number };
  // Kept for backward compatibility if navigation is called directly
  Loans: undefined;
  Home: undefined;
  Browse: { storageLocation?: StorageLocation } | undefined;
  Logbook: undefined;
};

const Stack = createNativeStackNavigator<RootStackParamList>();

const BootRouter = () => {
  return (
    <Stack.Navigator
      screenOptions={{ headerShown: false }}
      initialRouteName="Login"
    >
      <Stack.Screen name="Login" component={Login} />
      <Stack.Screen name="Main" component={TabRouter} />
      <Stack.Screen name="Account" component={Account} />
      <Stack.Screen name="GearItem" component={GearItem} />
    </Stack.Navigator>
  );
};

export default BootRouter;
