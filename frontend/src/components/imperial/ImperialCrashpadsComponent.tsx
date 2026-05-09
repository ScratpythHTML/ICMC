import { useGetCrashpads } from '@api/crashpads/crashpadsApi';
import type { CrashpadDto } from '@api/crashpads/crashpadsTypes';
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

const ImperialCrashpadsComponent = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const { data: crashpads } = useGetCrashpads(StorageLocation.Imperial);
  const handleOnPress = (item: CrashpadDto) => {
    navigation.navigate('ImperialCrashpadComponent', { id: item.id });
  };
  const renderGearItem = ({ item }: { item: CrashpadDto }) => (
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
        <FlatList data={crashpads} renderItem={renderGearItem} />
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

export default ImperialCrashpadsComponent;
