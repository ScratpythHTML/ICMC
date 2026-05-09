import { borderRadius, colours, spacing } from '@styles/variables';
import { LinearGradient } from 'expo-linear-gradient';
import { type StyleProp, StyleSheet, View, type ViewStyle } from 'react-native';

interface CardProps {
  children: React.ReactNode;
  style?: StyleProp<ViewStyle>;
  gradientColors?: string[];
}

export const Card = ({
  children,
  style,
  gradientColors = [colours.whiteOpacity, 'transparent'],
}: CardProps) => {
  return (
    <View style={[styles.container, style]}>
      <View style={styles.backdropClip}>
        <LinearGradient
          colors={gradientColors}
          style={styles.gradientBackground}
        />
      </View>
      <View style={styles.content}>{children}</View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    borderRadius: borderRadius.large,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
    overflow: 'hidden',
    backgroundColor: 'rgba(255, 255, 255, 0.03)',
  },
  gradientBackground: {
    ...StyleSheet.absoluteFillObject,
    opacity: 0.8,
  },
  backdropClip: {
    ...StyleSheet.absoluteFillObject,
    overflow: 'hidden',
  },
  content: {
    padding: spacing.medium,
  },
});
