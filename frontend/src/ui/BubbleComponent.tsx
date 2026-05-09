import { borderRadius, colours } from '@styles/variables';
import { LinearGradient } from 'expo-linear-gradient';
import type React from 'react';
import { type StyleProp, StyleSheet, View, type ViewStyle } from 'react-native';

export const BubbleComponent = ({
  children,
  style,
}: {
  children: React.ReactNode;
  style?: StyleProp<ViewStyle>;
}) => {
  return (
    <View style={[styles.container, style]}>
      <View style={styles.backdropClip}>
        <LinearGradient
          colors={[colours.purpleLight, 'transparent']}
          style={styles.gradientBackground}
        />
      </View>
      {children}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    borderRadius: borderRadius.xLarge,
    borderColor: colours.whiteOpacity,
  },
  gradientBackground: {
    ...StyleSheet.absoluteFillObject,
    opacity: 0.5,
  },
  backdropClip: {
    ...StyleSheet.absoluteFillObject,
    overflow: 'hidden',
    borderRadius: borderRadius.xLarge,
  },
});
