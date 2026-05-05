// import { AppRoutes } from '@navigation/appRoutes';
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
};

const Stack = createNativeStackNavigator<RootStackParamList>();

const BootRouter = () => {
  return (
    <Stack.Navigator>
      <Stack.Screen name="Account" component={Account} />
      <Stack.Screen name="Login" component={Login} />
      <Stack.Screen name="Imperial" component={Imperial} />
      <Stack.Screen name="Westway" component={Westway} />
      <Stack.Screen name="Home" component={Home} />
    </Stack.Navigator>
  );
};

export default BootRouter;
