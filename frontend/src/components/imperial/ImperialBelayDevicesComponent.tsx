import { useGetBelayDevices } from '@api/belay-devices/belayDevicesApi';
import type { BelayDeviceDto } from '@api/belay-devices/belayDevicesTypes';
import { colours, fonts } from '@styles/variables';
import { BubbleComponent } from '@ui/BubbleComponent';
import { FlatList, StyleSheet, Text } from 'react-native';

const ImperialBelayDevicesComponent = () => {
  const { data: belayDevices } = useGetBelayDevices('imperial');
  const renderGearItem = ({ item }: { item: BelayDeviceDto }) => (
    <BubbleComponent style={styles.bubble}>
      <Text>{item.brand}</Text>
    </BubbleComponent>
  );
  return <FlatList data={belayDevices} renderItem={renderGearItem} />;
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    flexDirection: 'column',
  },
  items: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    width: '80%',
  },
  bubble: {
    borderWidth: 1,
    flex: 1,
    width: '80%',
    fontSize: fonts.sizeExtraLarge,
    color: colours.blue,
  },
});

export default ImperialBelayDevicesComponent;
