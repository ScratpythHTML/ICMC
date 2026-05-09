import { fonts } from '@styles/variables';
import { StyleSheet, Text, View } from 'react-native';

const ImperialPreview = () => {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Imperial</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  container: { borderWidth: 1 },
  title: { borderWidth: 1, fontFamily: fonts.bold, fontSize: fonts.sizeLarge },
  previewItems: {
    borderWidth: 1,
    fontFamily: fonts.light,
    fontSize: fonts.sizeSmall,
  },
});

export default ImperialPreview;
