import { borderRadius, spacing } from '@styles/variables';
import { Plus } from 'lucide-react-native';
import { Pressable, StyleSheet, Text, View } from 'react-native';

const FooterComponent = ({ onRightPress }: { onRightPress: () => void }) => {
  return (
    <View style={styles.container}>
      <View style={styles.rightSection}>
        <Pressable style={styles.button} onPress={onRightPress}>
          <Plus size={16} />
          <Text>Add</Text>
        </Pressable>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    borderWidth: 1,
  },
  rightSection: {
    flex: 1,
    borderWidth: 1,
    justifyContent: 'flex-end',
    alignItems: 'flex-end',
  },
  button: {
    gap: spacing.small,
    borderWidth: 1,
    flexDirection: 'row',
    alignItems: 'center',
    borderRadius: borderRadius.xxLarge,
    paddingVertical: spacing.small,
    paddingHorizontal: spacing.medium,
  },
});

export default FooterComponent;
