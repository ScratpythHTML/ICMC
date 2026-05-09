// import { AppRoutes } from '@navigation/appRoutes';
import ImperialBelayDeviceComponent from '@components/imperial/ImperialBelayDeviceComponent';
import ImperialBelayDevicesComponent from '@components/imperial/ImperialBelayDevicesComponent';
import ImperialCarabinerComponent from '@components/imperial/ImperialCarabinerComponent';
import ImperialCarabinersComponent from '@components/imperial/ImperialCarabinersComponent';
import ImperialCrashpadComponent from '@components/imperial/ImperialCrashpadComponent';
import ImperialCrashpadsComponent from '@components/imperial/ImperialCrashpadsComponent';
import ImperialHarnessComponent from '@components/imperial/ImperialHarnessComponent';
import ImperialHarnessesComponent from '@components/imperial/ImperialHarnessesComponent';
import ImperialHelmetComponent from '@components/imperial/ImperialHelmetComponent';
import ImperialHelmetsComponent from '@components/imperial/ImperialHelmetsComponent';
import ImperialQuickdrawComponent from '@components/imperial/ImperialQuickdrawComponent';
import ImperialQuickdrawsComponent from '@components/imperial/ImperialQuickdrawsComponent';
import ImperialRopeComponent from '@components/imperial/ImperialRopeComponent';
import ImperialRopesComponent from '@components/imperial/ImperialRopesComponent';
import WestwayBelayDeviceComponent from '@components/westway/WestwayBelayDeviceComponent';
import WestwayBelayDevicesComponent from '@components/westway/WestwayBelayDevicesComponent';
import WestwayCarabinerComponent from '@components/westway/WestwayCarabinerComponent';
import WestwayCarabinersComponent from '@components/westway/WestwayCarabinersComponent';
import WestwayCrashpadComponent from '@components/westway/WestwayCrashpadComponent';
import WestwayCrashpadsComponent from '@components/westway/WestwayCrashpadsComponent';
import WestwayHarnessComponent from '@components/westway/WestwayHarnessComponent';
import WestwayHarnessesComponent from '@components/westway/WestwayHarnessesComponent';
import WestwayHelmetComponent from '@components/westway/WestwayHelmetComponent';
import WestwayHelmetsComponent from '@components/westway/WestwayHelmetsComponent';
import WestwayQuickdrawComponent from '@components/westway/WestwayQuickdrawComponent';
import WestwayQuickdrawsComponent from '@components/westway/WestwayQuickdrawsComponent';
import WestwayRopeComponent from '@components/westway/WestwayRopeComponent';
import WestwayRopesComponent from '@components/westway/WestwayRopesComponent';
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
  ImperialCarabinersComponent: undefined;
  ImperialCarabinerComponent: { id: number };
  ImperialCrashpadsComponent: undefined;
  ImperialCrashpadComponent: { id: number };
  ImperialHarnessesComponent: undefined;
  ImperialHarnessComponent: { id: number };
  ImperialHelmetsComponent: undefined;
  ImperialHelmetComponent: { id: number };
  ImperialQuickdrawsComponent: undefined;
  ImperialQuickdrawComponent: { id: number };
  ImperialRopesComponent: undefined;
  ImperialRopeComponent: { id: number };
  WestwayBelayDevicesComponent: undefined;
  WestwayBelayDeviceComponent: { id: number };
  WestwayCarabinersComponent: undefined;
  WestwayCarabinerComponent: { id: number };
  WestwayCrashpadsComponent: undefined;
  WestwayCrashpadComponent: { id: number };
  WestwayHarnessesComponent: undefined;
  WestwayHarnessComponent: { id: number };
  WestwayHelmetsComponent: undefined;
  WestwayHelmetComponent: { id: number };
  WestwayQuickdrawsComponent: undefined;
  WestwayQuickdrawComponent: { id: number };
  WestwayRopesComponent: undefined;
  WestwayRopeComponent: { id: number };
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
      <Stack.Screen
        name="ImperialCarabinersComponent"
        component={ImperialCarabinersComponent}
      />
      <Stack.Screen
        name="ImperialCarabinerComponent"
        component={ImperialCarabinerComponent}
      />
      <Stack.Screen
        name="ImperialCrashpadsComponent"
        component={ImperialCrashpadsComponent}
      />
      <Stack.Screen
        name="ImperialCrashpadComponent"
        component={ImperialCrashpadComponent}
      />
      <Stack.Screen
        name="ImperialHarnessesComponent"
        component={ImperialHarnessesComponent}
      />
      <Stack.Screen
        name="ImperialHarnessComponent"
        component={ImperialHarnessComponent}
      />
      <Stack.Screen
        name="ImperialHelmetsComponent"
        component={ImperialHelmetsComponent}
      />
      <Stack.Screen
        name="ImperialHelmetComponent"
        component={ImperialHelmetComponent}
      />
      <Stack.Screen
        name="ImperialQuickdrawsComponent"
        component={ImperialQuickdrawsComponent}
      />
      <Stack.Screen
        name="ImperialQuickdrawComponent"
        component={ImperialQuickdrawComponent}
      />
      <Stack.Screen
        name="ImperialRopesComponent"
        component={ImperialRopesComponent}
      />
      <Stack.Screen
        name="ImperialRopeComponent"
        component={ImperialRopeComponent}
      />
      <Stack.Screen
        name="WestwayBelayDevicesComponent"
        component={WestwayBelayDevicesComponent}
      />
      <Stack.Screen
        name="WestwayBelayDeviceComponent"
        component={WestwayBelayDeviceComponent}
      />
      <Stack.Screen
        name="WestwayCarabinersComponent"
        component={WestwayCarabinersComponent}
      />
      <Stack.Screen
        name="WestwayCarabinerComponent"
        component={WestwayCarabinerComponent}
      />
      <Stack.Screen
        name="WestwayCrashpadsComponent"
        component={WestwayCrashpadsComponent}
      />
      <Stack.Screen
        name="WestwayCrashpadComponent"
        component={WestwayCrashpadComponent}
      />
      <Stack.Screen
        name="WestwayHarnessesComponent"
        component={WestwayHarnessesComponent}
      />
      <Stack.Screen
        name="WestwayHarnessComponent"
        component={WestwayHarnessComponent}
      />
      <Stack.Screen
        name="WestwayHelmetsComponent"
        component={WestwayHelmetsComponent}
      />
      <Stack.Screen
        name="WestwayHelmetComponent"
        component={WestwayHelmetComponent}
      />
      <Stack.Screen
        name="WestwayQuickdrawsComponent"
        component={WestwayQuickdrawsComponent}
      />
      <Stack.Screen
        name="WestwayQuickdrawComponent"
        component={WestwayQuickdrawComponent}
      />
      <Stack.Screen
        name="WestwayRopesComponent"
        component={WestwayRopesComponent}
      />
      <Stack.Screen
        name="WestwayRopeComponent"
        component={WestwayRopeComponent}
      />
    </Stack.Navigator>
  );
};

export default BootRouter;
