import { useUpdateGearItem } from '@api/gear-items/gearItemsApi';
import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import { searchUsers } from '@api/users/usersService';
import { useUserContext } from '@contexts/UserContext';
import { colours, spacing, borderRadius } from '@styles/variables';
import { Body, Subheading, Label } from '@ui/Typography';
import { X, Search, Package, User } from 'lucide-react-native';
import { useState, useEffect } from 'react';
import { 
  Modal, 
  ScrollView, 
  StyleSheet, 
  TouchableOpacity, 
  View, 
  TextInput,
  ActivityIndicator
} from 'react-native';
import { DatePicker } from '@ui/DatePicker';

interface LendGearModalProps {
  visible: boolean;
  onClose: () => void;
}

const LendGearModal = ({ visible, onClose }: LendGearModalProps) => {
  const { user } = useUserContext();
  const [userSearch, setUserSearch] = useState('');
  const [gearSearch, setGearSearch] = useState('');
  const [selectedUser, setSelectedUser] = useState<any>(null);
  const [selectedGear, setSelectedGear] = useState<any>(null);
  const [userResults, setUserResults] = useState<any[]>([]);
  const [isSearchingUsers, setIsSearchingUsers] = useState(false);
  
  const [expectedReturnDate, setExpectedReturnDate] = useState<string>(
    new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString()
  );

  const { mutateAsync: updateGearItem, isPending: isSubmitting } = useUpdateGearItem();

  // Manual search for users since we want to search by name/cid/email
  useEffect(() => {
    const performUserSearch = async () => {
      if (userSearch.length < 2 || selectedUser) {
        setUserResults([]);
        return;
      }
      setIsSearchingUsers(true);
      try {
        const results = await searchUsers({ search: userSearch });
        setUserResults(results || []);
      } catch (e) {
        console.error(e);
      } finally {
        setIsSearchingUsers(false);
      }
    };

    const timer = setTimeout(performUserSearch, 300);
    return () => clearTimeout(timer);
  }, [userSearch, selectedUser]);

  // Gear search using the existing hook (filtering by brand/model/toughTag)
  const { data: gearResults } = useSearchGearItems({ search: gearSearch });

  const handleLend = async () => {
    if (!selectedUser || !selectedGear) return;

    try {
      await updateGearItem({
        id: selectedGear.id,
        request: {
          id: selectedGear.id,
          lentToUserId: selectedUser.id,
          lentByUserId: user?.id,
          lentDate: new Date().toISOString(),
          expectedReturnDate: expectedReturnDate,
          returnedDate: null,
        }
      });
      onClose();
      // Reset state
      setSelectedUser(null);
      setSelectedGear(null);
      setUserSearch('');
      setGearSearch('');
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <Modal visible={visible} animationType="slide" presentationStyle="pageSheet">
      <View style={styles.container}>
        <View style={styles.header}>
          <Subheading>Lend Gear</Subheading>
          <TouchableOpacity onPress={onClose}>
            <X size={24} color={colours.textPrimary} />
          </TouchableOpacity>
        </View>

        <ScrollView contentContainerStyle={styles.content} keyboardShouldPersistTaps="handled">
          {/* User Search */}
          <View style={styles.section}>
            <Label style={styles.sectionLabel}>Member</Label>
            {selectedUser ? (
              <TouchableOpacity style={styles.selectedItem} onPress={() => setSelectedUser(null)}>
                <User size={20} color={colours.blue} />
                <Body style={styles.selectedText}>{selectedUser.fullName}</Body>
                <X size={16} color={colours.textMuted} />
              </TouchableOpacity>
            ) : (
              <View style={styles.searchContainer}>
                <Search size={18} color={colours.textMuted} />
                <TextInput
                  style={styles.input}
                  placeholder="Search Member..."
                  placeholderTextColor={colours.textMuted}
                  value={userSearch}
                  onChangeText={setUserSearch}
                  keyboardAppearance="dark"
                />
                {isSearchingUsers && <ActivityIndicator size="small" color={colours.blue} />}
              </View>
            )}
            {!selectedUser && userResults.length > 0 && (
              <View style={styles.results}>
                {userResults.slice(0, 3).map(u => (
                  <TouchableOpacity key={u.id} style={styles.resultItem} onPress={() => setSelectedUser(u)}>
                    <View style={styles.userResultInfo}>
                      <Body>{u.fullName}</Body>
                      <Label style={styles.userSubText}>{u.cid || u.email}</Label>
                    </View>
                  </TouchableOpacity>
                ))}
              </View>
            )}
          </View>

          {/* Gear Search */}
          <View style={styles.section}>
            <Label style={styles.sectionLabel}>Gear Item</Label>
            {selectedGear ? (
              <TouchableOpacity style={styles.selectedItem} onPress={() => setSelectedGear(null)}>
                <Package size={20} color={colours.pink} />
                <Body style={styles.selectedText}>{selectedGear.brand} {selectedGear.model} (#{selectedGear.toughTag})</Body>
                <X size={16} color={colours.textMuted} />
              </TouchableOpacity>
            ) : (
              <View style={styles.searchContainer}>
                <Search size={18} color={colours.textMuted} />
                <TextInput
                  style={styles.input}
                  placeholder="Search Gear..."
                  placeholderTextColor={colours.textMuted}
                  value={gearSearch}
                  onChangeText={setGearSearch}
                  keyboardAppearance="dark"
                />
              </View>
            )}
            {!selectedGear && gearSearch.length > 0 && (
              <View style={styles.results}>
                {gearResults?.filter(g => !g.lentToUserId).slice(0, 3).map(g => (
                  <TouchableOpacity key={g.id} style={styles.resultItem} onPress={() => setSelectedGear(g)}>
                    <Body>{g.brand} {g.model}</Body>
                    <Label>#{g.toughTag}</Label>
                  </TouchableOpacity>
                ))}
              </View>
            )}
          </View>

          {/* Date Picker */}
          <View style={styles.section}>
            <Label style={styles.sectionLabel}>Expected Return</Label>
            <DatePicker
              label="Return Date"
              value={expectedReturnDate}
              onChange={(v) => setExpectedReturnDate(v || new Date().toISOString())}
            />
          </View>

          <TouchableOpacity 
            style={[styles.submitButton, (!selectedUser || !selectedGear || isSubmitting) && styles.submitButtonDisabled]}
            onPress={handleLend}
            disabled={!selectedUser || !selectedGear || isSubmitting}
          >
            {isSubmitting ? (
              <ActivityIndicator color="#fff" />
            ) : (
              <Body style={styles.submitButtonText}>Confirm Loan</Body>
            )}
          </TouchableOpacity>
        </ScrollView>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colours.background,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: colours.whiteOpacity,
  },
  content: {
    padding: spacing.medium,
    gap: spacing.large,
  },
  section: {
    gap: spacing.small,
  },
  sectionLabel: {
    color: colours.textPrimary,
    fontWeight: '700',
  },
  searchContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.surface,
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    height: 50,
    gap: spacing.small,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  input: {
    flex: 1,
    color: colours.textPrimary,
    fontSize: 16,
  },
  results: {
    backgroundColor: colours.surface,
    borderRadius: borderRadius.medium,
    overflow: 'hidden',
    marginTop: spacing.xxSmall,
  },
  resultItem: {
    padding: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: colours.whiteOpacity,
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  userResultInfo: {
    flex: 1,
    gap: 2,
  },
  userSubText: {
    fontSize: 10,
    color: colours.textMuted,
  },
  selectedItem: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.surfaceLight,
    padding: spacing.medium,
    borderRadius: borderRadius.medium,
    gap: spacing.medium,
    borderWidth: 1,
    borderColor: colours.blue,
  },
  selectedText: {
    flex: 1,
    fontWeight: '600',
  },
  submitButton: {
    backgroundColor: colours.blue,
    height: 56,
    borderRadius: borderRadius.medium,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: spacing.medium,
  },
  submitButtonDisabled: {
    opacity: 0.5,
  },
  submitButtonText: {
    color: '#fff',
    fontWeight: '700',
    fontSize: 18,
  },
});

export default LendGearModal;