import { queryClient } from '@api/queryClient';
import Home from '@pages/Home';
import { QueryClientProvider } from '@tanstack/react-query';
import { View } from 'react-native';

export default function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <View>
        <Home />
      </View>
    </QueryClientProvider>
  );
}
