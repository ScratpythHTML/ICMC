import { useGetCarabiners } from '@api/carabiners/carabinersApi';
import type { CarabinerDto } from '@api/carabiners/carabinersTypes';
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

const ImperialCarabinersComponent = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const { data: carabiners } = useGetCarabiners(StorageLocation.Imperial);
  const handleOnPress = (item: CarabinerDto) => {
    navigation.navigate('ImperialCarabinerComponent', { id: item.id });
  };
  const renderGearItem = ({ item }: { item: CarabinerDto }) => (
    <TouchableOpacity onPress={() => handleOnPress(item)}>
      <BubbleComponent style={styles.bubble}>
        <Text>{item.brand}</Text>
        <Text>{item.dateOfPurchase}</Text>
        <Text>{item.inspectedBy}</Text>
        <Text>{item.lastInspection}</Text>
        <Text>{item.manufacturerExpiry}</Text>
        <Text>{item.model}</Text>
        <Text>{item.nextInspection}</Text>
        <Text>{item.toughTag}</Text>
        <Text>{item.storageLocation}</Text>
        <Text>{item.id}</Text>
      </BubbleComponent>
    </TouchableOpacity>
  );
  return (
    <BackgroundComponent>
      <View style={styles.container}>
        <FlatList data={carabiners} renderItem={renderGearItem} />
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
    gap: 10,
  },
});

export default ImperialCarabinersComponent;
