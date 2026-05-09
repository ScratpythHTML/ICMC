import { useGetBelayDevices } from '@api/belay-devices/belayDevicesApi';
import type { BelayDeviceDto } from '@api/belay-devices/belayDevicesTypes';
import { StorageLocation } from '@api/common/enums';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, fonts } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import {
  FlatList,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';

const WestwayBelayDevicesComponent = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const { data: belayDevices } = useGetBelayDevices(StorageLocation.Westway);
  const handleOnPress = (item: BelayDeviceDto) => {
    navigation.navigate('WestwayBelayDeviceComponent', { id: item.id });
  };
  const renderGearItem = ({ item }: { item: BelayDeviceDto }) => (
    <TouchableOpacity onPress={() => handleOnPress(item)}>
      <BubbleComponent style={styles.bubble}>
        <Text>{item.brand}</Text>
      </BubbleComponent>
    </TouchableOpacity>
  );
  return (
    <BackgroundComponent>
      <View style={styles.container}>
        <FlatList data={belayDevices} renderItem={renderGearItem} />
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    flexDirection: 'column',
  },
  bubble: {
    borderWidth: 1,
    flex: 1,
    width: '100%',
    fontSize: fonts.sizeExtraLarge,
    color: colours.blue,
  },
});

export default WestwayBelayDevicesComponent;
