// import { AppRoutes } from '@navigation/appRoutes';
import ImperialBelayDeviceComponent from '@components/imperial/ImperialBelayDeviceComponent';
import ImperialBelayDevicesComponent from '@components/imperial/ImperialBelayDevicesComponent';
import Account from '@pages/Account';
import Home from '@pages/Home';
import Imperial from '@pages/Imperial';
import Login from '@pages/Login';
import Westway from '@pages/Westway';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

export type RootStackParamList = {
  Account: undefined;
  Login: undefined;
  Imperial: undefined;
  Westway: undefined;
  Home: undefined;
  ImperialBelayDevicesComponent: undefined;
  ImperialBelayDeviceComponent: { id: number };
};

const Stack = createNativeStackNavigator<RootStackParamList>();

const BootRouter = () => {
  return (
    <Stack.Navigator
      screenOptions={{ headerShown: false }}
      initialRouteName="Login"
    >
      <Stack.Screen name="Account" component={Account} />
      <Stack.Screen name="Login" component={Login} />
      <Stack.Screen name="Imperial" component={Imperial} />
      <Stack.Screen name="Westway" component={Westway} />
      <Stack.Screen name="Home" component={Home} />
      <Stack.Screen
        name="ImperialBelayDevicesComponent"
        component={ImperialBelayDevicesComponent}
      />
      <Stack.Screen
        name="ImperialBelayDeviceComponent"
        component={ImperialBelayDeviceComponent}
      />
    </Stack.Navigator>
  );
};

export default BootRouter;
