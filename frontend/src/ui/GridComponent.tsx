import { FlatList, StyleSheet, Text, TouchableOpacity } from 'react-native';
import { BubbleComponent } from './BubbleComponent';

export type GridItem = {
  label?: string;
};

type GridComponentProps = {
  items: GridItem[];
  //   onPress: () => void;
};

const GridComponent = ({ items }: GridComponentProps) => {
  const renderGearCategory = ({ item }: { item: GridItem }) => (
    <TouchableOpacity>
      <BubbleComponent style={styles.bubble}>
        <Text>{item.label}</Text>
      </BubbleComponent>
    </TouchableOpacity>
  );
  return (
    <FlatList
      data={items}
      renderItem={renderGearCategory}
      numColumns={2}
      columnWrapperStyle={styles.listContainer}
      contentContainerStyle={styles.listContent}
    />
  );
};

const styles = StyleSheet.create({
  listContainer: {
    flex: 1,
    justifyContent: 'space-evenly',
  },
  listContent: {
    flexGrow: 1,
    justifyContent: 'space-evenly',
  },
  bubble: {
    flex: 1,
    padding: 50,
  },
});

export default GridComponent;
