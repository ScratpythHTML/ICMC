import { colours } from '@styles/variables';
import { LinearGradient } from 'expo-linear-gradient';
import { StyleSheet, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';

const BackgroundComponent = () => {
  const insets = useSafeAreaInsets();

  const safeAreaStyle = {
    flex: 1,
    paddingTop: insets.top,
    paddingBottom: insets.bottom,
  };

  return (
    <View style={safeAreaStyle}>
      <LinearGradient
        colors={[colours.blue, colours.green]}
        start={{ x: 0.5, y: 0 }}
        end={{ x: 0.5, y: 1 }}
        style={StyleSheet.absoluteFillObject}
      />
    </View>
  );
};

export default BackgroundComponent;
