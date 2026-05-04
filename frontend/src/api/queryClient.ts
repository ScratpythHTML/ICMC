import { QueryClient } from '@tanstack/react-query';

const defaultQueryConfig = {
  refetchOnWindowFocus: true,
  refetchOnMount: true,
  refetchInterval: 300000,
  staleTime: 300000,
};

export const queryClient = new QueryClient({
  defaultOptions: { queries: defaultQueryConfig },
});
