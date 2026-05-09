import { Picker } from '@react-native-picker/picker';
import { borderRadius, colours, spacing } from '@styles/variables';
import { ChevronDown } from 'lucide-react-native';
import { useState } from 'react';
import { Platform, StyleSheet, TouchableOpacity, View } from 'react-native';
import { Body, Label } from './Typography';

interface DropdownOption {
  label: string;
  value: string | number | undefined;
}

interface DropdownProps {
  label: string;
  options: DropdownOption[];
  selectedValue?: string | number;
  onValueChange: (value: any) => void;
}

export const Dropdown = ({
  label,
  options,
  selectedValue,
  onValueChange,
}: DropdownProps) => {
  const [show, setShow] = useState(false);

  const selectedOption = options.find((o) => o.value === selectedValue);
  const displayLabel = selectedOption ? selectedOption.label : 'Select...';

  const handleValueChange = (value: any) => {
    onValueChange(value);
    if (Platform.OS === 'android') {
      setShow(false);
    }
  };

  return (
    <View style={styles.container}>
      <Label style={styles.label}>{label}</Label>

      <TouchableOpacity
        style={styles.trigger}
        onPress={() => setShow(!show)}
        activeOpacity={0.7}
      >
        <Body style={styles.triggerText}>{displayLabel}</Body>
        <ChevronDown size={20} color="rgba(255, 255, 255, 0.5)" />
      </TouchableOpacity>

      {show && (
        <View
          style={
            Platform.OS === 'ios'
              ? styles.iosPickerContainer
              : styles.androidPickerContainer
          }
        >
          <Picker
            selectedValue={selectedValue}
            onValueChange={handleValueChange}
            style={styles.picker}
            dropdownIconColor="#fff"
            itemStyle={styles.itemStyle}
          >
            {options.map((option) => (
              <Picker.Item
                key={option.value?.toString() || 'undefined'}
                label={option.label}
                value={option.value}
                color={Platform.OS === 'ios' ? '#fff' : '#000'}
              />
            ))}
          </Picker>
          {Platform.OS === 'ios' && (
            <TouchableOpacity
              style={styles.doneButton}
              onPress={() => setShow(false)}
            >
              <Body style={styles.doneText}>Done</Body>
            </TouchableOpacity>
          )}
        </View>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: spacing.medium,
    width: '100%',
  },
  label: {
    color: '#fff',
    marginBottom: spacing.xSmall,
    opacity: 0.8,
  },
  trigger: {
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    paddingVertical: spacing.small,
    borderWidth: 1,
    borderColor: 'rgba(255, 255, 255, 0.1)',
    height: 50,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  triggerText: {
    color: '#fff',
    fontSize: 16,
  },
  iosPickerContainer: {
    backgroundColor: 'rgba(0,0,0,0.8)',
    borderRadius: borderRadius.medium,
    marginTop: spacing.small,
    padding: spacing.small,
  },
  androidPickerContainer: {
    backgroundColor: '#fff',
    borderRadius: borderRadius.medium,
    marginTop: spacing.small,
  },
  picker: {
    color: '#fff',
    width: '100%',
    ...Platform.select({
      ios: {
        height: 200,
      },
      android: {
        height: 50,
        color: '#000',
      },
    }),
  },
  itemStyle: {
    fontSize: 16,
    height: 200,
  },
  doneButton: {
    alignItems: 'center',
    paddingVertical: spacing.small,
    borderTopWidth: 1,
    borderTopColor: 'rgba(255,255,255,0.1)',
  },
  doneText: {
    color: colours.blue,
    fontWeight: '700',
  },
});
