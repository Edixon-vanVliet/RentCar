import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home";
import { BrandsPage } from "./pages/Brands/BrandsPage";
import { FuelTypesPage } from "./pages/FuelType.cs/FuelTypesPage";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/brands",
    element: <BrandsPage />,
  },
  {
    path: "/fuelTypes",
    element: <FuelTypesPage />,
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
