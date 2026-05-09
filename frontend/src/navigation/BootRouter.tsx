import type { GearCategory, StorageLocation } from '@api/common/enums';
import Account from '@pages/Account';
import GearItem from '@pages/GearItem';
import GearItems from '@pages/GearItems';
import Home from '@pages/Home';
import Login from '@pages/Login';
import Storage from '@pages/Storage';

import { createNativeStackNavigator } from '@react-navigation/native-stack';

export type RootStackParamList = {
  Account: undefined;
  GearItems: { gearCategory: GearCategory; storageLocation: StorageLocation };
  GearItem: { id: number };
  Home: undefined;
  Login: undefined;
  Storage: { storageLocation: StorageLocation };
};

const Stack = createNativeStackNavigator<RootStackParamList>();

const BootRouter = () => {
  return (
    <Stack.Navigator
      screenOptions={{ headerShown: false }}
      initialRouteName="Login"
    >
      <Stack.Screen name="Account" component={Account} />
      <Stack.Screen name="Home" component={Home} />
      <Stack.Screen name="GearItems" component={GearItems} />
      <Stack.Screen name="GearItem" component={GearItem} />
      <Stack.Screen name="Login" component={Login} />
      <Stack.Screen name="Storage" component={Storage} />
    </Stack.Navigator>
  );
};

export default BootRouter;
