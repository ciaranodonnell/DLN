using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLN.AMQP.Frames.Performatives
{
    class OpenFrame : AMQPFrame
    {

        /*From the spec:
 <type name="open" class="composite" source="list" provides="frame">
    <descriptor name="amqp:open:list" code="0x00000000:0x00000010"/>
    <field name="container-id" type="string" mandatory="true"/>
    <field name="hostname" type="string"/>
    <field name="max-frame-size" type="uint" default="4294967295"/>
    <field name="channel-max" type="ushort" default="65535"/>
    <field name="idle-time-out" type="milliseconds"/>
    <field name="outgoing-locales" type="ietf-language-tag" multiple="true"/>
    <field name="incoming-locales" type="ietf-language-tag" multiple="true"/>
    <field name="offered-capabilities" type="symbol" multiple="true"/>
    <field name="desired-capabilities" type="symbol" multiple="true"/>
    <field name="properties" type="fields"/>
</type>
*/

        public OpenFrame(BinaryReader reader, int doff, int size, int channelNumber) : base(reader, doff, size, channelNumber)
        {

            this.ContainerId = ReadString(reader);
            this.HostName = ReadString(reader);



        }

        public string ContainerId { get; }
        public string HostName { get; }
    }
}
