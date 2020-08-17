export const DateFromDate = (date: Date) => {
    const dateString = date.toISOString().split('T')[0];
    return new Date(dateString);
  };
  