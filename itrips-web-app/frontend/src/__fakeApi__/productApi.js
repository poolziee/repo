class ProductsApi {
    getHotels() {
        const products = [
            {
                id: '1',
                name: 'Hotel Royal Spa',
                stars: '4',
                total_bookings: '180',
                country: 'Bulgaria',
                city: 'Velingrad',
                street: '123',
                date_created: '12-06-2014'
            },
            {
                id: '2',
                name: 'Hotel Forest Resort',
                stars: '5',
                total_bookings: '300',
                country: 'Bulgaria',
                city: 'Sofia',
                street: '54',
                date_created: '17-04-2019'
            },
            {
                id: '3',
                name: 'Hostel Rila Mountain',
                stars: '2',
                total_bookings: '16',
                country: 'Bulgaria',
                city: 'Svoge',
                street: '125',
                date_created: '08-04-2021'
            }
        ];

        return Promise.resolve(products);
    }
}

export const productApi = new ProductsApi();
