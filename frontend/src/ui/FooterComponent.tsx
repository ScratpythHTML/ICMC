import { borderRadius, colours, spacing } from '@styles/variables';
import { Plus } from 'lucide-react-native';
import { Pressable, StyleSheet, View } from 'react-native';
import { Label } from './Typography';

const FooterComponent = ({ onRightPress }: { onRightPress: () => void }) => {
  return (
    <View style={styles.container}>
      <Pressable style={styles.addButton} onPress={onRightPress}>
        <Plus size={24} color="#fff" />
        <Label style={styles.label}>Add Gear</Label>
      </Pressable>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: spacing.medium,
    alignItems: 'center',
    justifyContent: 'center',
  },
  addButton: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.purple,
    borderRadius: borderRadius.xxLarge,
    paddingVertical: spacing.regular,
    paddingHorizontal: spacing.xLarge,
    gap: spacing.small,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 4,
    elevation: 8,
  },
  label: {
    color: '#fff',
    marginBottom: 0,
    fontWeight: '700',
  },
});

export default FooterComponent;
