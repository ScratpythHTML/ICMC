import { queryClient } from '@api/queryClient';
import BootRouter from '@navigation/BootRouter';
import { DefaultTheme, NavigationContainer } from '@react-navigation/native';
import { QueryClientProvider } from '@tanstack/react-query';
import BackgroundComponent from '@ui/BackgroundComponent';
import { StyleSheet, View } from 'react-native';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { StorageLocationProvider } from './src/contexts/StorageLocationContext';

export default function App() {
  const NavTheme = {
    ...DefaultTheme,
    colors: {
      ...DefaultTheme.colors,
      background: 'transparent',
    },
  };
  return (
    <SafeAreaProvider>
      <QueryClientProvider client={queryClient}>
        <StorageLocationProvider>
          <View style={styles.backgroundLayer}>
            <BackgroundComponent />
          </View>
          <View style={styles.appLayer}>
            <NavigationContainer theme={NavTheme}>
              <BootRouter />
            </NavigationContainer>
          </View>
        </StorageLocationProvider>
      </QueryClientProvider>
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  backgroundLayer: {
    position: 'absolute',
    top: 0,
    bottom: 0,
    left: 0,
    right: 0,
  },
  appLayer: {
    flex: 1,
    backgroundColor: 'transparent',
  },
});
