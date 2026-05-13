import React from 'react';
import { View, TouchableOpacity, StyleSheet } from 'react-native';
import { createBottomTabNavigator, type BottomTabBarProps } from '@react-navigation/bottom-tabs';
import { useUserContext } from '@contexts/UserContext';
import { colours } from '@styles/variables';
import { Home, Search, History, Book } from 'lucide-react-native';
import HomePage from '@pages/Home';
import Browse from '@pages/Browse';
import Loans from '@pages/Loans';
import Logbook from '@pages/Logbook';
import type { RootStackParamList } from '@navigation/BootRouter';

const Tab = createBottomTabNavigator<RootStackParamList>();

/**
 * A completely custom tab bar component.
 * This guarantees absolute control over flexbox layouts so icons are mathematically centered,
 * bypassing any internal margins/paddings React Navigation injects.
 */
const CustomTabBar = ({ state, descriptors, navigation }: BottomTabBarProps) => {
  return (
    <View style={styles.tabBarContainer}>
      <View style={styles.tabBar}>
        {state.routes.map((route, index) => {
          const { options } = descriptors[route.key];
          const isFocused = state.index === index;

          const onPress = () => {
            const event = navigation.emit({
              type: 'tabPress',
              target: route.key,
              canPreventDefault: true,
            });

            if (!isFocused && !event.defaultPrevented) {
              navigation.navigate(route.name);
            }
          };

          const color = isFocused ? colours.blue : colours.textMuted;
          const size = 24;

          // Determine which icon to render based on the route name
          let Icon = Home;
          if (route.name === 'Loans') Icon = History;
          if (route.name === 'Home') Icon = Home;
          if (route.name === 'Browse') Icon = Search;
          if (route.name === 'Logbook') Icon = Book;

          return (
            <TouchableOpacity
              key={index}
              accessibilityRole="button"
              accessibilityState={isFocused ? { selected: true } : {}}
              accessibilityLabel={options.tabBarAccessibilityLabel}
              testID={options.tabBarTestID}
              onPress={onPress}
              style={styles.tabItem}
              activeOpacity={0.8}
            >
              <Icon color={color} size={size} />
            </TouchableOpacity>
          );
        })}
      </View>
    </View>
  );
};

const TabRouter = () => {
  const { user } = useUserContext();
  const isAdmin = user?.isAdmin === true;

  return (
    <Tab.Navigator
      tabBar={(props) => <CustomTabBar {...props} />}
      screenOptions={{ headerShown: false }}
    >
      {isAdmin && <Tab.Screen name="Loans" component={Loans} />}
      <Tab.Screen name="Home" component={HomePage} />
      <Tab.Screen name="Browse" component={Browse} />
      {isAdmin && <Tab.Screen name="Logbook" component={Logbook} />}
    </Tab.Navigator>
  );
};

const styles = StyleSheet.create({
  tabBarContainer: {
    position: 'absolute',
    bottom: 32,
    left: 48,
    right: 48,
  },
  tabBar: {
    flexDirection: 'row',
    height: 64,
    backgroundColor: colours.surface,
    borderRadius: 32,
    borderWidth: 1,
    borderColor: colours.whiteOpacityStrong,
    elevation: 12,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 6 },
    shadowOpacity: 0.4,
    shadowRadius: 12,
    alignItems: 'center',
    justifyContent: 'space-around',
  },
  tabItem: {
    flex: 1,
    height: '100%',
    // This mathematically guarantees vertical and horizontal centering
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default TabRouter;
