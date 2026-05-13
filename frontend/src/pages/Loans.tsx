import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import { Body, Heading, Label, Subheading } from '@ui/Typography';
import { Calendar, Plus, User, ArrowRight } from 'lucide-react-native';
import { useState } from 'react';
import { FlatList, StyleSheet, TouchableOpacity, View, ActivityIndicator, RefreshControl } from 'react-native';
import { formatDate } from '@utils/enumHelpers';
import LendGearModal from '@components/modals/LendGearModal';
import ReturnGearModal from '@components/modals/ReturnGearModal';

const Loans = () => {
  const { data: allGearItems, isLoading, isFetching, refetch } = useSearchGearItems({});
  
  const activeLoans = allGearItems?.filter(item => item.lentDate && !item.returnedDate) || [];

  const [lendModalVisible, setLendModalVisible] = useState(false);
  const [returnModalVisible, setReturnModalVisible] = useState(false);
  const [selectedGearItem, setSelectedGearItem] = useState<any>(null);

  const handleReturnPress = (item: any) => {
    setSelectedGearItem(item);
    setReturnModalVisible(true);
  };

  const renderLoanItem = ({ item }: { item: any }) => (
    <Card style={styles.loanCard}>
      <View style={styles.loanHeader}>
        <View style={styles.gearInfo}>
          <Subheading style={styles.brand}>{item.brand}</Subheading>
          <Body style={styles.model}>{item.model || 'Unknown Model'}</Body>
        </View>
        <View style={styles.tagBadge}>
          <Label style={styles.tagText}>#{item.toughTag}</Label>
        </View>
      </View>
      
      <View style={styles.divider} />
      
      <View style={styles.loanDetails}>
        <View style={styles.detailItem}>
          <Label style={styles.detailLabel}>LENT TO</Label>
          <View style={styles.detailRow}>
            <User size={14} color={colours.blue} />
            <Body style={styles.detailValue}>Name: {item.lentToUserName || `ID: ${item.lentToUserId}`}</Body>
          </View>
        </View>

        <View style={styles.detailItem}>
          <Label style={styles.detailLabel}>DUE DATE</Label>
          <View style={styles.detailRow}>
            <Calendar size={14} color={colours.pink} />
            <Body style={styles.detailValue}>{formatDate(item.expectedReturnDate)}</Body>
          </View>
        </View>
      </View>

      <TouchableOpacity 
        style={styles.returnButton}
        onPress={() => handleReturnPress(item)}
      >
        <Body style={styles.returnButtonText}>Mark as Returned</Body>
        <ArrowRight size={14} color={colours.blue} />
      </TouchableOpacity>
    </Card>
  );

  return (
    <BackgroundComponent>
      <View style={styles.container}>
        <View style={styles.header}>
          <View>
            <Heading>Active Loans</Heading>
            <Body color={colours.textMuted}>{activeLoans.length} items currently out</Body>
          </View>
          <TouchableOpacity 
            style={styles.lendButton}
            onPress={() => setLendModalVisible(true)}
            activeOpacity={0.8}
          >
            <Plus size={20} color="#fff" />
            <Body style={styles.lendButtonText}>Lend</Body>
          </TouchableOpacity>
        </View>

        {isLoading ? (
          <View style={styles.centerContainer}>
            <ActivityIndicator color={colours.blue} size="large" />
          </View>
        ) : (
          <FlatList
            data={activeLoans}
            renderItem={renderLoanItem}
            keyExtractor={(item) => item.id.toString()}
            contentContainerStyle={styles.listContent}
            refreshControl={
              <RefreshControl 
                refreshing={isFetching && !isLoading} 
                onRefresh={refetch} 
                tintColor={colours.blue}
                colors={[colours.blue]}
              />
            }
            ListEmptyComponent={
              <View style={styles.emptyContainer}>
                <View style={styles.emptyIcon}>
                  <Calendar size={48} color={colours.whiteOpacityStrong} />
                </View>
                <Body color={colours.textMuted}>No active loans found.</Body>
                <Label style={styles.emptyLabel}>Everything is in storage</Label>
              </View>
            }
          />
        )}
      </View>
      
      <LendGearModal 
        visible={lendModalVisible} 
        onClose={() => setLendModalVisible(false)} 
      />

      <ReturnGearModal
        visible={returnModalVisible}
        onClose={() => {
          setReturnModalVisible(false);
          setSelectedGearItem(null);
        }}
        gearItem={selectedGearItem}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: spacing.medium,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: spacing.medium,
    marginTop: spacing.small,
  },
  lendButton: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.blue,
    paddingHorizontal: spacing.medium,
    paddingVertical: spacing.small,
    borderRadius: 100,
    gap: spacing.xSmall,
    elevation: 4,
    shadowColor: colours.blue,
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 8,
  },
  lendButtonText: {
    color: '#fff',
    fontWeight: '700',
  },
  listContent: {
    gap: spacing.small,
    paddingBottom: 120,
  },
  loanCard: {
    padding: spacing.small,
  },
  loanHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
  },
  gearInfo: {
    flex: 1,
  },
  brand: {
    marginBottom: 0,
    fontSize: 16,
  },
  model: {
    fontSize: 12,
    opacity: 0.8,
  },
  tagBadge: {
    backgroundColor: colours.whiteOpacityStrong,
    paddingHorizontal: 6,
    paddingVertical: 2,
    borderRadius: 4,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  tagText: {
    color: colours.textPrimary,
    fontWeight: '700',
    fontSize: 9,
  },
  divider: {
    height: 1,
    backgroundColor: colours.whiteOpacity,
    marginVertical: spacing.small,
  },
  loanDetails: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    gap: spacing.small,
  },
  detailItem: {
    flex: 1,
    gap: 2,
  },
  detailLabel: {
    fontSize: 9,
  },
  detailRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.small,
    marginTop: 0,
  },
  detailValue: {
    fontSize: 12,
    fontWeight: '600',
    color: colours.textPrimary,
  },
  returnButton: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: spacing.small,
    marginTop: spacing.medium,
    paddingVertical: 8,
    backgroundColor: colours.whiteOpacity,
    borderRadius: 6,
  },
  returnButtonText: {
    fontSize: 12,
    fontWeight: '700',
    color: colours.blue,
  },
  centerContainer: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  emptyContainer: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingTop: spacing.xxxLarge,
    gap: spacing.small,
  },
  emptyIcon: {
    width: 80,
    height: 80,
    borderRadius: 40,
    backgroundColor: colours.surface,
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: spacing.medium,
  },
  emptyLabel: {
    fontSize: 10,
    letterSpacing: 2,
  },
});

export default Loans;