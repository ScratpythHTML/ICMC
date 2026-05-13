import { colours } from '@styles/variables';
import { StyleSheet, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';

const BackgroundComponent = ({ children }: { children?: React.ReactNode }) => {
  const insets = useSafeAreaInsets();

  return (
    <View style={styles.container}>
      <View
        style={{
          flex: 1,
          paddingTop: insets.top,
          paddingBottom: insets.bottom,
        }}
      >
        {children}
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colours.background,
  },
});

export default BackgroundComponent;
