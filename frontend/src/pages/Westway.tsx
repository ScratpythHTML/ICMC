import type { BelayDeviceDto } from '@api/belay-devices/belayDevicesTypes';
import ImperialBelayDevicesComponent from '@components/imperial/ImperialBelayDevicesComponent';
import { colours, fonts } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import GridComponent from '@ui/GridComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { StyleSheet, Text, View } from 'react-native';

const Westway = () => {
  const gearCategories = [
    {
      label: 'Belay Devices',
    },
    {
      label: 'Carabiners',
    },
    {
      label: 'Crashpads',
    },
    {
      label: 'Harnesses',
    },
    {
      label: 'Helmets',
    },
    {
      label: 'Ropes',
    },
  ];
  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.container}>
        <GridComponent items={gearCategories} />
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});
export default Westway;
