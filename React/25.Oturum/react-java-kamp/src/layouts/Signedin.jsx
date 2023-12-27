import React from "react";
import { Dropdown, Image, Menu } from "semantic-ui-react";
export default function SignedIn({signOut}) {
  return (
    <div>
      <Menu.Item>
        <Image
          avatar
          spaced="right"
          src="https://e1.pngegg.com/pngimages/720/455/png-clipart-msn-crystalgloss-occupe-icon-thumbnail.png"
        />
        <Dropdown pointing="top right" text="Admin">
          <Dropdown.Menu>
            <Dropdown.Item text="Bilgilerim" icon="info" />
            <Dropdown.Item
              onClick={signOut}
              text="Cikis Yap"
              icon="sign-out"
            />
          </Dropdown.Menu>
        </Dropdown>
      </Menu.Item>
    </div>
  );
}
